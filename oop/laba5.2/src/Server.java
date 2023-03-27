import java.io.*;
import java.net.*;
import java.util.LinkedList;

class ServerStaff extends Thread {

    private Socket socket;
    private BufferedReader in; // поток чтения из сокета
    private BufferedWriter out; // поток записи в сокет
    private BufferedReader inputUser;
    private String text;


    public ServerStaff(Socket socket) throws IOException {
        this.socket = socket;
        inputUser = new BufferedReader(new InputStreamReader(System.in));
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
        new WriteNotification().start();
        start(); // вызываем run()
    }
    @Override
    public void run() {
        String word;
        try {
            // первое сообщение отправленное сюда - это никнейм
            word = in.readLine();
            try {
                out.write(word + "\n");
                out.flush();
            } catch (IOException ignored) {}

            try {
                while (true) {
                    word = in.readLine();
                    if(word.equals("stop")) {
                        this.downService();
                        break;
                    }
                    System.out.println("Сообщение: " + word);
                    for (ServerStaff vr : Server.serverList) {
                        vr.send(word); // отослать принятое сообщение с привязанного клиента всем остальным влючая его
                    }
                }

            } catch (NullPointerException ignored) {}

        } catch (IOException e) {
            this.downService();
        }

    }


     //отсылка одного сообщения клиенту

    private void send(String msg) {
        try {
            out.write(msg + "\n");
            out.flush();
        } catch (IOException ignored) {}

    }
     //отсылка одного уведомления клиенту

    public class WriteNotification extends Thread {

        @Override
        public void run() {
            while (true) {
                String userWord;
                try {
                    userWord = inputUser.readLine(); // сообщения с консоли
                    for (ServerStaff vr : Server.serverList) {
                        vr.send(userWord); // отослать принятое сообщение с привязанного клиента всем остальным влючая его
                    }
                } catch (IOException e) {}

            }
        }
    }

    private void downService() {
        try {
            if(!socket.isClosed()) {
                socket.close();
                in.close();
                out.close();
                for (ServerStaff vr : Server.serverList) {
                    if(vr.equals(this)) vr.interrupt();
                    Server.serverList.remove(this);
                }
            }
        } catch (IOException ignored) {}
    }
}

public class Server {

    public static final int PORT = 8080;
    public static LinkedList<ServerStaff> serverList = new LinkedList<>();
    private String text;


    public static void main(String[] args) throws IOException {
        ServerSocket server = new ServerSocket(PORT);
        System.out.println("Server Started");
        try {
            while (true) {

                Socket socket = server.accept();
                try {
                    serverList.add(new ServerStaff(socket));
                } catch (IOException e) {

                    socket.close();
                }
            }

        } finally {
            server.close();
        }
    }
}