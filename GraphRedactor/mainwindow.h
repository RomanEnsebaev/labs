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

    QPixmap img; //Изображение и его временная копия
    QPixmap imgTmp;
    bool isPressed; //Нажата ли кнопка мыши
    QPointF current; //Различные точки, необходимые для отрисовки
    QPointF next;
    QPointF currentTmp;
    QLabel *label; //Метка, в которой отображается рисунок
    int instrument; //Выбранный инструмент
    QColor color; //Цвет
    QPainter painter; //Объект, который занимается отрисовкой
    int widthOfPen; //Ширина кисти

protected:
    void paintEvent(QPaintEvent *); //Событие рисования
    void mouseMoveEvent(QMouseEvent *ev); //Движения курсора
    void mousePressEvent(QMouseEvent *ev); //Нажатия на кнопку мыши
    void mouseReleaseEvent(QMouseEvent *ev); //Отпускания зажатой кнопки мыши


private:
  Ui::MainWindow *ui; //Интерфейс
  void createActions(); //Метод создания меню
  void loadFile(const QString &fileName); //Метод загрузки файла по пути


public slots:
  void newFile(); //Новый файл
  void open(); //Открытие
  bool save(); //Сохранение
  void pen(); //Выбор кисти
  void setColor(); //Выбор цвета
public:
  explicit MainWindow(QWidget *parent = 0); //Конструктор
  ~MainWindow();

};

#endif // MAINWINDOW_H
