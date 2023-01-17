#pragma once

#include <vector>

class ResultContainer
{
public:
    std::vector<double> x;
    std::vector<double> y;
    std::vector<std::vector<double>> d;

    std::vector<double> xExtra;
    std::vector<double> yExtra;
    std::vector<double> yApproxExtra;

    std::vector<double> errors;
    double maxError;
};