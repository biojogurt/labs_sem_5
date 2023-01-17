#pragma once

#include "Graphs.h"
#include <QMainWindow>

namespace Ui
{
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget* parent = nullptr);
    ~MainWindow();

private slots:
    void checkFields();

private:
    Ui::MainWindow* ui;
    QPointer<QIntValidator> val;
    QPointer<Graphs> g;
};