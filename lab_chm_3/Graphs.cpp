#include "Graphs.h"
#include "ui_Graphs.h"
#include <QSplineSeries>
#include <QValueAxis>

Graphs::Graphs(int whatFunction, int a, int b, int n, QWidget* parent) :
    QWidget(parent),
    ui(new Ui::Graphs)
{
    ui->setupUi(this);
    setAttribute(Qt::WA_DeleteOnClose);
    setWindowFlags(Qt::Window);
    setStyleSheet(
        "QTableWidget {"
        "qproperty-showGrid: \"false\";"
        "}"
        "QTableWidget::item {"
        "border: 0px;"
        "border-top: 1px solid #3B4252;"
        "border-left: 1px solid #3B4252;"
        "}"
        "QHeaderView::section:vertical {"
        "border: 0px;"
        "border-top: 1px solid #3B4252;"
        "}"
        "QHeaderView::section:horizontal {"
        "border: 0px;"
        "border-left: 1px solid #3B4252;"
        "}"
        "QHeaderView::section {"
        "font-size: 12pt;"
        "}"
        "QLabel {"
        "font-size: 12pt;"
        "}"
    );

    int k = 50;
    InterpolationController ic(a, b, n, k);

    ResultContainer rcEven = ic.calculate(whatFunction, true);
    ResultContainer rcChebyshev = ic.calculate(whatFunction, false);

    setValuesTable(rcEven, ui->ValuesEvenTable);
    setDivisionsTable(rcEven, ui->DivisionsEvenTable);

    setValuesTable(rcChebyshev, ui->ValuesChebyshevTable);
    setDivisionsTable(rcChebyshev, ui->DivisionsChebyshevTable);

    setErrorTable(n, rcEven, rcChebyshev);

    double from = whatFunction == 1 ? -25 : whatFunction == 2 ? -1 : 0;
    double to = whatFunction == 1 ? 25 : whatFunction == 2 ? 1 : whatFunction == 3 ? 600 : b;
    double interval = whatFunction == 1 ? 5 : whatFunction == 2 ? 0.5 : whatFunction == 3 ? 50 : 1;

    setFunctionGraphsChart(a, b, n, k, rcEven, ui->FunctionGraphsEvenChart, from, to, interval);
    setFunctionGraphsChart(a, b, n, k, rcChebyshev, ui->FunctionGraphsChebyshevChart, from, to, interval);

    setErrorGraphsChart(a, b, n, k, rcEven, rcChebyshev, ui->ErrorGraphsChart);
}

Graphs::~Graphs()
{
    delete ui;
}

void Graphs::setValuesTable(ResultContainer rc, QTableWidget* tableWidget)
{
    std::vector<double> x = rc.x;
    std::vector<double> y = rc.y;

    if (x.size() <= 10)
    {
        tableWidget->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
        tableWidget->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    }

    QStringList horizontalHeaders;

    for (int i = 0; i < x.size(); i++)
    {
        tableWidget->insertColumn(i);

        horizontalHeaders.emplace_back(std::to_string(i).c_str());

        QLabel* labelX = new QLabel(std::to_string(x[i]).c_str());
        labelX->setMargin(3);
        labelX->setAlignment(Qt::AlignCenter);
        tableWidget->setCellWidget(0, i, labelX);

        QLabel* labelY = new QLabel(std::to_string(y[i]).c_str());
        labelY->setMargin(3);
        labelY->setAlignment(Qt::AlignCenter);
        tableWidget->setCellWidget(1, i, labelY);
    }

    tableWidget->setHorizontalHeaderLabels(horizontalHeaders);
}

void Graphs::setDivisionsTable(ResultContainer rc, QTableWidget* tableWidget)
{
    std::vector<double> x = rc.x;
    std::vector<std::vector<double>> d = rc.d;

    tableWidget->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    tableWidget->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    tableWidget->verticalHeader()->setDefaultAlignment(Qt::AlignCenter);

    QStringList horizontalHeaders;
    QStringList verticalHeaders;

    for (int i = 0; i < x.size(); i++)
    {
        tableWidget->insertRow(i);
        tableWidget->insertColumn(i);

        horizontalHeaders.emplace_back(std::to_string(i).c_str());
        verticalHeaders.emplace_back(std::to_string(x[i]).c_str());
    }

    for (int i = 0; i < x.size(); i++)
    {
        for (int j = 0; j < x.size() - i; j++)
        {
            QLabel* labelD = new QLabel(std::to_string(d[i][j]).c_str());
            labelD->setMargin(3);
            labelD->setAlignment(Qt::AlignCenter);
            tableWidget->setCellWidget(i, j, labelD);
        }
    }

    tableWidget->setHorizontalHeaderLabels(horizontalHeaders);
    tableWidget->setVerticalHeaderLabels(verticalHeaders);
}

void Graphs::setErrorTable(int n, ResultContainer rcEven, ResultContainer rcChebyshev)
{
    ui->ErrorsTable->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->ErrorsTable->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    QLabel* labelPower = new QLabel(std::to_string(n).c_str());
    labelPower->setMargin(3);
    labelPower->setAlignment(Qt::AlignCenter);
    ui->ErrorsTable->setCellWidget(0, 0, labelPower);

    QLabel* labelMaxErrorEven = new QLabel(std::format("{:.18f}", rcEven.maxError).c_str());
    labelMaxErrorEven->setMargin(3);
    labelMaxErrorEven->setAlignment(Qt::AlignCenter);
    ui->ErrorsTable->setCellWidget(0, 1, labelMaxErrorEven);

    QLabel* labelMaxErrorChebyshev = new QLabel(std::format("{:.18f}", rcChebyshev.maxError).c_str());
    labelMaxErrorChebyshev->setMargin(3);
    labelMaxErrorChebyshev->setAlignment(Qt::AlignCenter);
    ui->ErrorsTable->setCellWidget(0, 2, labelMaxErrorChebyshev);
}

void Graphs::setFunctionGraphsChart(int a, int b, int n, int k, ResultContainer rc, QChartView* chartView, double from, double to, double interval)
{
    std::vector<double> xExtra = rc.xExtra;
    std::vector<double> yExtra = rc.yExtra;
    std::vector<double> yApproxExtra = rc.yApproxExtra;

    QChart* chart = new QChart();
    QLineSeries* seriesExact = new QLineSeries();
    QLineSeries* seriesApproximate = new QLineSeries();
    QValueAxis* axisX = new QValueAxis();
    QValueAxis* axisY = new QValueAxis();

    for (int i = 0; i <= n * k; i++)
    {
        seriesExact->append(xExtra[i], yExtra[i]);
        seriesApproximate->append(xExtra[i], yApproxExtra[i]);
    }

    seriesExact->setName("Точный");
    seriesApproximate->setName("Приближенный");

    QPen pen;
    pen.setWidth(6);
    pen.setColor(Qt::blue);
    pen.setStyle(Qt::SolidLine);
    seriesExact->setPen(pen);

    pen.setWidth(6);
    pen.setColor(Qt::red);
    pen.setStyle(Qt::DotLine);
    seriesApproximate->setPen(pen);

    chart->addSeries(seriesExact);
    chart->addSeries(seriesApproximate);
    chart->addAxis(axisX, Qt::AlignBottom);
    chart->addAxis(axisY, Qt::AlignLeft);

    axisX->setRange(a, b);
    axisX->setTickType(QValueAxis::TicksDynamic);
    axisX->setTickAnchor(0.0);
    axisX->setTickInterval(1);

    seriesExact->attachAxis(axisX);
    seriesApproximate->attachAxis(axisX);

    axisY->setRange(from, to);
    axisY->setTickType(QValueAxis::TicksDynamic);
    axisY->setTickAnchor(0.0);
    axisY->setTickInterval(interval);

    seriesExact->attachAxis(axisY);
    seriesApproximate->attachAxis(axisY);

    chartView->setChart(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
}

void Graphs::setErrorGraphsChart(int a, int b, int n, int k, ResultContainer rcEven, ResultContainer rcChebyshev, QChartView* chartView)
{
    std::vector<double> xEven = rcEven.xExtra;
    std::vector<double> errorsEven = rcEven.errors;
    std::vector<double> xChebyshev = rcChebyshev.xExtra;
    std::vector<double> errorsChebyshev = rcChebyshev.errors;

    QChart* chart = new QChart();
    QLineSeries* seriesEven = new QLineSeries();
    QLineSeries* seriesChebyshev = new QLineSeries();
    QValueAxis* axisX = new QValueAxis();
    QValueAxis* axisY = new QValueAxis();

    for (int i = 0; i <= n * k; i++)
    {
        seriesEven->append(xEven[i], errorsEven[i]);
        seriesChebyshev->append(xChebyshev[i], errorsChebyshev[i]);
    }

    seriesEven->setName("Погрешность при равномерном разбиении");
    seriesChebyshev->setName("Погрешность при разбиении Чебышева");

    QPen pen;
    pen.setWidth(5);
    pen.setColor(Qt::blue);
    pen.setStyle(Qt::SolidLine);
    seriesEven->setPen(pen);

    pen.setWidth(5);
    pen.setColor(Qt::red);
    pen.setStyle(Qt::DotLine);
    seriesChebyshev->setPen(pen);

    chart->addSeries(seriesEven);
    chart->addSeries(seriesChebyshev);
    chart->addAxis(axisX, Qt::AlignBottom);
    chart->addAxis(axisY, Qt::AlignLeft);

    axisX->setRange(a, b);
    axisX->setTickType(QValueAxis::TicksDynamic);
    axisX->setTickAnchor(0.0);
    axisX->setTickInterval(0.5);

    seriesEven->attachAxis(axisX);
    seriesChebyshev->attachAxis(axisX);

    //axisY->setRange(0, 200);

    seriesEven->attachAxis(axisY);
    seriesChebyshev->attachAxis(axisY);

    chartView->setChart(chart);
    chartView->setRenderHint(QPainter::Antialiasing);
}