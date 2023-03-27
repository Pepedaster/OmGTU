import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

class Clock {
    private int hours;
    private int minutes;

    public Clock(int hours, int minutes) {  //функция-конструктор
        this.setHours(hours);
        this.setMinutes(minutes);
    }

    public void setMinutes(int minutes) {
        this.minutes = minutes % 60;
    }

    public int getMinutes() {
        return minutes;
    }

    public void setHours(int hours) {
        this.hours = hours % 24;
    }

    public int getHours() {
        return hours;
    }
}

public class Main extends JPanel {  //extends наследует свойства класса

    private Clock clock;

    public Main(Clock сlock) {
        setPreferredSize(new Dimension(600, 400));
        setClock(сlock);
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g); //для правильной отрисовки
        if (clock != null) {
            drawClock(g, clock);
        }
    }

//    public Point convertCoordinatesToPanel(Point point) {
//        Point O = new Point(getSize().width / 2, getSize().height / 2);
//        return new Point(O.x + point.x, O.y - point.y);
//    }

    private Point getEndPoint(double angle, int radius) {
        Point O = new Point(getSize().width/2, getSize().height / 2);
        int x = (int) (O.x + radius * Math.cos(angle));
        int y = (int) (O.y - radius * Math.sin(angle));
        return new Point(x, y);
  }

    private void drawClock(Graphics g, Clock сlock) {
        Point O = new Point(getSize().width / 2, getSize().height / 2);
        int radiusClock = Math.min(O.x, O.y) - 20;
        int radiusMinute = radiusClock - 10;
        int radiusHour = radiusMinute - 20;
        double angle;

        angle = Math.PI / 2 - (clock.getHours() + clock.getMinutes() / 60.0) * Math.PI / 6;
        Point point = getEndPoint(angle, radiusHour);
        g.setColor(Color.GREEN);
        g.drawLine(O.x, O.y, point.x, point.y);

        angle = Math.PI / 2 - clock.getMinutes() * Math.PI / 30;
        point = getEndPoint(angle, radiusMinute);
        g.setColor(Color.GRAY);
        g.drawLine(O.x, O.y, point.x, point.y);
    }

    public Clock getClock() {
        return clock;
    }

    public void setClock(Clock clock) {
        this.clock = clock;
    }

    public static void main(String[] args) throws Exception {
        JFrame f = new JFrame("Часы");
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        f.setLayout(new BorderLayout());

        final Main clockPanel = new Main(new Clock(0, 0));
        clockPanel.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
        f.add(clockPanel, BorderLayout.CENTER);
        JPanel controlPanel = new JPanel();
        controlPanel.setBorder(BorderFactory.createTitledBorder("Настройки"));
        controlPanel.setLayout(new GridLayout(2, 2, 6, 6));

        JButton but = (JButton) controlPanel.add(new JButton("Часы +1"));
        but.putClientProperty("plus", true);
        ActionListener alHours = new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                JButton b = (JButton) e.getSource();
                boolean plus = ((Boolean) b.getClientProperty("plus")).booleanValue();
                clockPanel.getClock().setHours(clockPanel.getClock().getHours() + (plus ? 1 : -1));
                clockPanel.repaint();
            }

        };
        but.addActionListener(alHours);

        but = (JButton) controlPanel.add(new JButton("Часы -1"));
        but.putClientProperty("plus", false);
        but.addActionListener(alHours);

        but = (JButton) controlPanel.add(new JButton("Минуты +1"));
        but.putClientProperty("plus", true);
        ActionListener alMinutes = new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                JButton b = (JButton) e.getSource();
                boolean plus = ((Boolean) b.getClientProperty("plus")).booleanValue();
                clockPanel.getClock().setMinutes(clockPanel.getClock().getMinutes() + (plus ? 1 : -1));
                clockPanel.repaint();
            }

        };
        but.addActionListener(alMinutes);

        but = (JButton) controlPanel.add(new JButton("Минуты -1"));
        but.putClientProperty("plus", false);
        but.addActionListener(alMinutes);

        f.add(controlPanel, BorderLayout.SOUTH);
        f.pack();
        f.setVisible(true);
    }

}