#pragma once
#include "ResultContainer.h"

class InterpolationController
{
private:
    long                             a;
    long                             b;
    size_t                           n;
    size_t                           k;

public:
    InterpolationController(long a, long b, size_t n, size_t k);
    ResultContainer                  calculate(int whatFunction, bool isEven);

private:
    std::vector<double>              calculateX(double a, double b, int n, bool isEven);
    std::vector<double>              calculateXEven(double a, double b, int n);
    std::vector<double>              calculateXChebyshev(double a, double b, int n);

    std::vector<double>              calculateY(std::vector<double> x, int whatFunction);
    std::vector<double>              calculateY1(std::vector<double> x);
    std::vector<double>              calculateY2(std::vector<double> x);
    std::vector<double>              calculateY3(std::vector<double> x);
    std::vector<double>              calculateY4(std::vector<double> x);

    std::vector<double>              calculateEndConditions(std::vector<double> x, int whatFunction);
    std::vector<double>              calculateEndConditions1(std::vector<double> x);
    std::vector<double>              calculateEndConditions2(std::vector<double> x);
    std::vector<double>              calculateEndConditions3(std::vector<double> x);
    std::vector<double>              calculateEndConditions4(std::vector<double> x);

    std::vector<std::vector<double>> calculateD(std::vector<double> x, std::vector<double> y, int n);
    std::vector<double>              calculateH(std::vector<double> x);
    std::vector<double>              calculateM(std::vector<double> h, std::vector<double> x, std::vector<std::vector<double>> d, std::vector<double> endConditions);

    std::vector<double>              calculateYApprox(std::vector<double> h, std::vector<double> M, std::vector<double> xOrig, std::vector<double> yOrig, std::vector<double> x, int i, int k);
    std::vector<double>              calculateErrors(std::vector<double> y, std::vector<double> yApprox, int n);
    double                           calculateMaxError(std::vector<double> errors, double maxError);

    std::vector<double>              calculateTridiagonalMatrix(std::vector<double> x, std::vector<double> a, std::vector<double> b, std::vector<double> c, std::vector<double> d);
};