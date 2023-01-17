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
    std::vector<double>              calculateXEven(double a, double b, int n);
    std::vector<double>              calculateXChebyshev(double a, double b, int n);

    std::vector<double>              calculateY1(std::vector<double> x);
    std::vector<double>              calculateY2(std::vector<double> x);
    std::vector<double>              calculateY3(std::vector<double> x);
    std::vector<double>              calculateY4(std::vector<double> x);

    std::vector<std::vector<double>> calculateD(std::vector<double> x, std::vector<double> y, int n);
    std::vector<double>              calculateYApprox(std::vector<std::vector<double>> d, std::vector<double> xOrig, std::vector<double> x, std::vector<double> y, int n, int k);

    std::vector<double>              calculateErrors(std::vector<double> y, std::vector<double> yApprox, int n);
    double                           calculateMaxError(std::vector<double> errors, double maxError);
};