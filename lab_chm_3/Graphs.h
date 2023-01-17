#pragma once

#include "InterpolationController.h"
#include <QWidget>
#include <QTableWidget>
#include <QChartView>

namespace Ui
{
    class Graphs;
}

class Graphs : public QWidget
{
    Q_OBJECT

public:
    Graphs(int whatFunction, int a, int b, int n, QWidget* parent = nullptr);
    ~Graphs();

private:
    void setValuesTable(ResultContainer rc, QTableWidget* tableWidget);
    void setDivisionsTable(ResultContainer rc, QTableWidget* tableWidget);
    void setErrorTable(int n, ResultContainer rcEven, ResultContainer rcChebyshev);
    void setFunctionGraphsChart(int a, int b, int n, int k, ResultContainer rc, QChartView* chartView, double from, double to, double interval);
    void setErrorGraphsChart(int a, int b, int n, int k, ResultContainer rcEven, ResultContainer rcChebyshev, QChartView* chartView);

private:
    Ui::Graphs* ui;
};