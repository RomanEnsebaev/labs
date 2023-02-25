#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QtWidgets>



namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QPixmap img; 
    QPixmap imgTmp;
    bool isPressed; 
    QPointF current; 
    QPointF next;
    QPointF currentTmp;
    QLabel *label; 
    int instrument; 
    QColor color; 
    QPainter painter; 
    int widthOfPen; 

protected:
    void paintEvent(QPaintEvent *); 
    void mouseMoveEvent(QMouseEvent *ev); 
    void mousePressEvent(QMouseEvent *ev); 
    void mouseReleaseEvent(QMouseEvent *ev); 


private:
  Ui::MainWindow *ui; 
  void createActions(); 
  void loadFile(const QString &fileName); 


public slots:
  void newFile(); 
  void open(); 
  bool save(); 
  void pen(); 
  void setColor(); 
public:
  explicit MainWindow(QWidget *parent = 0);
  ~MainWindow();

};

#endif 
