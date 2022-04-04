#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QSaveFile>
#include <QString>
#include <QFile>


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    label = new QLabel(ui->scrollArea); //Метку
    label->setAlignment(Qt::AlignTop); //Выравниваем содержимое
    ui->scrollArea->setWidget(label);
    createActions(); //Создаем меню
    repaint(); //Перерисовываем
    instrument = 1; //Выбираем карандаш
    color.setRgb(0, 0, 0); //Черный цвет

    widthOfPen = 5; //Ставим ширину кисти

    newFile(); //Новый файл
}


void MainWindow::paintEvent(QPaintEvent *) { //Отрисовка (событие)
  if (instrument == 1) { //Если карандаш выбран
    if (isPressed) { //Если кнопка зажата
      painter.begin(&img); //Рисуем по координатам
      painter.setPen(QPen(color, widthOfPen, Qt::SolidLine));
      painter.drawLine(current, next);
      painter.end();
    }
    current = next;
    label->setPixmap(img);
  }
}

void MainWindow::mouseMoveEvent(QMouseEvent *ev) { //Событие движения курсора, расчет координат под курсором
  next = ev->pos() - ui->scrollArea->geometry().topLeft() +
         QPoint(ui->scrollArea->horizontalScrollBar()->value(),
                ui->scrollArea->verticalScrollBar()->value());
  repaint();
}

void MainWindow::pen() { instrument = 1; }

void MainWindow::setColor() { //Выбор цвета
  const QColor newColor = QColorDialog::getColor(color); //Диалог выбора цвета
  if (newColor.isValid()) {
    color = newColor; //Ставим цвет, если он валидный

  }

  repaint();
}
void MainWindow::mousePressEvent(QMouseEvent *ev)
{
      isPressed = true;
      current = ev->pos() - ui->scrollArea->geometry().topLeft() +
                QPoint(ui->scrollArea->horizontalScrollBar()->value(),
                       ui->scrollArea->verticalScrollBar()->value());
      next = current;
}

void MainWindow::mouseReleaseEvent(QMouseEvent *ev) { //Событие отпускания зажатой кнопки мыши, отрисовка примитивов
  isPressed = false;
  next = ev->pos() - ui->scrollArea->geometry().topLeft() +
         QPoint(ui->scrollArea->horizontalScrollBar()->value(),
                ui->scrollArea->verticalScrollBar()->value());
}

void MainWindow::newFile() { loadFile("d:\\img.jpg"); } //Новый файл

void MainWindow::open() { //Открыть файл
  const QString fileName = QFileDialog::getOpenFileName(
      this, tr("Открыть файл"), QDir::currentPath());
  if (!fileName.isEmpty())
    loadFile(fileName);
}

bool MainWindow::save() { //Сохранение
    const QString initialPath = QDir::currentPath() + "/untitled.jpg";

    const QString fileName =
        QFileDialog::getSaveFileName(this, tr("Сохранить как"), initialPath,
                                     tr("JPG Files (*.jpg);;All Files (*)"));
    return !fileName.isEmpty() && img.save(fileName, "jpg");
}


void MainWindow::loadFile(const QString &fileName) { //Загрузка файла
  if (!fileName.isEmpty()) {
    img.load(fileName);
    label->setPixmap(img);
  }
}

void MainWindow::createActions() { //Создаем меню "Файл"
  QMenu *fileMenu = menuBar()->addMenu(tr("&Файл"));
  QAction *newAct = fileMenu->addAction(tr("&Новый файл"));
  newAct->setShortcuts(QKeySequence::New);
  connect(newAct, SIGNAL(triggered(bool)), SLOT(newFile()));

  QAction *openAct = fileMenu->addAction(tr("&Открыть файл"));
  openAct->setShortcuts(QKeySequence::Open);
  connect(openAct, SIGNAL(triggered(bool)), SLOT(open()));

  QAction *saveAct = fileMenu->addAction(tr("&Сохранить как"));
  saveAct->setShortcuts(QKeySequence::Save);
  connect(saveAct, SIGNAL(triggered(bool)), SLOT(save()));
}


MainWindow::~MainWindow()
{
    delete ui;
}
