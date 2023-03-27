import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import javax.swing.*;
public class Main {
    public static void main(String[] args) {
        JFrame fr=new JFrame("Вращение треугольника вокруг своего центра тяжести");
        fr.setPreferredSize( new Dimension(300,400));
        final JPanel pan= new JPanel();
        final JPanel controlPanel = new JPanel();
        pan.setLayout(null);
        fr.add(pan);
        fr.add(controlPanel);
        int h = 0;
        int m = 0;
        JButton buttonMP = new JButton("Minute+");
        buttonMP.putClientProperty("plus",true);
        JButton buttonMM = new JButton("Minute-");
        JButton buttonHP = new JButton("Hour+");
        JButton buttonHM = new JButton("Hour-");
        ActionListener hours = new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JButton b = (JButton) e.getSource();
                if ((Boolean) (b.getClientProperty("plus"))){

                }
            }
        }

        fr.setVisible(true);
        fr.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        fr.pack();
        Timer tm= new Timer(500, new ActionListener(){
            int i=0;
            @Override
            public void actionPerformed(ActionEvent arg0) {
                Graphics2D gr=(Graphics2D)pan.getRootPane().getGraphics();
                pan.update(gr);
                GeneralPath path=new GeneralPath();
                GeneralPath path2=new GeneralPath();
                path.append(new Polygon(new int []{150,200},new int[]{150,150},2),true);
                path2.append(new Polygon(new int []{150,150},new int[]{150,50},2),true);
                AffineTransform tranforms = AffineTransform.getRotateInstance((i++)*0.001, 150, 150);
                gr.transform(tranforms);
                gr.draw(path);

                AffineTransform tranforms2 = AffineTransform.getRotateInstance((i++)*0.01, 150, 150);
                gr.transform(tranforms2);
                gr.draw(path2);
            }});

        tm.start();


    }

}