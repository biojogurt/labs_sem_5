#include "MainWindow.h"
#include "ui_MainWindow.h"

MainWindow::MainWindow(QWidget* parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow),
    g(nullptr)
{
    ui->setupUi(this);

    val = new QIntValidator(INT_MIN, INT_MAX, this);
    ui->LineA->setValidator(val);
    ui->LineB->setValidator(val);
    ui->LineN->setValidator(val);

    connect(ui->ButtonResult, &QPushButton::clicked, this, &MainWindow::checkFields);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::checkFields()
{
    ui->LineA->setPalette(QApplication::palette(ui->LineA));
    ui->LineB->setPalette(QApplication::palette(ui->LineB));
    ui->LineN->setPalette(QApplication::palette(ui->LineN));

    if (!ui->LineA->text().isEmpty() && ui->LineA->text() != "-" &&
        !ui->LineB->text().isEmpty() && ui->LineB->text() != "-" &&
        !ui->LineN->text().isEmpty() && ui->LineN->text() != "-")
    {
        g = new Graphs(ui->Func1->isChecked() ? 1 : ui->Func2->isChecked() ? 2 : ui->Func3->isChecked() ? 3 : 4,
            std::stoi(ui->LineA->text().toStdString()),
            std::stoi(ui->LineB->text().toStdString()),
            std::stoi(ui->LineN->text().toStdString()), this);
        g->show();
    }
    else
    {
        QPalette palette;
        palette.setColor(QPalette::Base, QColor(255, 111, 111));

        if (ui->LineA->text().isEmpty() || ui->LineA->text() == "-")
        {
            ui->LineA->setPalette(palette);
        }

        if (ui->LineB->text().isEmpty() || ui->LineB->text() == "-")
        {
            ui->LineB->setPalette(palette);
        }

        if (ui->LineN->text().isEmpty() || ui->LineN->text() == "-")
        {
            ui->LineN->setPalette(palette);
        }
    }
}