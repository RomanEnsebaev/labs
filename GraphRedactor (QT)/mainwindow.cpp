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
    label = new QLabel(ui->scrollArea); 
    label->setAlignment(Qt::AlignTop); 
    ui->scrollArea->setWidget(label);
    createActions(); 
    repaint(); 
    instrument = 1; 
    color.setRgb(0, 0, 0); 

    widthOfPen = 5; 

    newFile(); 
}


void MainWindow::paintEvent(QPaintEvent *) { 
  if (instrument == 1) { 
    if (isPressed) { 
      painter.begin(&img); 
      painter.setPen(QPen(color, widthOfPen, Qt::SolidLine));
      painter.drawLine(current, next);
      painter.end();
    }
    current = next;
    label->setPixmap(img);
  }
}

void MainWindow::mouseMoveEvent(QMouseEvent *ev) { 
  next = ev->pos() - ui->scrollArea->geometry().topLeft() +
         QPoint(ui->scrollArea->horizontalScrollBar()->value(),
                ui->scrollArea->verticalScrollBar()->value());
  repaint();
}

void MainWindow::pen() { instrument = 1; }

void MainWindow::setColor() { 
  const QColor newColor = QColorDialog::getColor(color); 
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

void MainWindow::mouseReleaseEvent(QMouseEvent *ev) { 
  isPressed = false;
  next = ev->pos() - ui->scrollArea->geometry().topLeft() +
         QPoint(ui->scrollArea->horizontalScrollBar()->value(),
                ui->scrollArea->verticalScrollBar()->value());
}

void MainWindow::newFile() { loadFile("d:\\img.jpg"); } 

void MainWindow::open() { //Открыть файл
  const QString fileName = QFileDialog::getOpenFileName(
      this, tr("Открыть файл"), QDir::currentPath());
  if (!fileName.isEmpty())
    loadFile(fileName);
}

bool MainWindow::save() { 
    const QString initialPath = QDir::currentPath() + "/untitled.jpg";

    const QString fileName =
        QFileDialog::getSaveFileName(this, tr("Сохранить как"), initialPath,
                                     tr("JPG Files (*.jpg);;All Files (*)"));
    return !fileName.isEmpty() && img.save(fileName, "jpg");
}


void MainWindow::loadFile(const QString &fileName) { 
  if (!fileName.isEmpty()) {
    img.load(fileName);
    label->setPixmap(img);
  }
}

void MainWindow::createActions() {
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
