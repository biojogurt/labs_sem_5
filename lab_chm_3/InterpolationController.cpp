#include "InterpolationController.h"
#include <algorithm>
#include <functional>
#include <numbers>

InterpolationController::InterpolationController(long a, long b, size_t n, size_t k) : a(a), b(b), n(n), k(k)
{}

ResultContainer InterpolationController::calculate(int whatFunction, bool isEven)
{
    ResultContainer resultContainer;

    resultContainer.x
        = isEven
        ? calculateXEven(a, b, n)
        : calculateXChebyshev(a, b, n);

    resultContainer.y
        = whatFunction == 1
        ? calculateY1(resultContainer.x)
        : whatFunction == 2
        ? calculateY2(resultContainer.x)
        : whatFunction == 3
        ? calculateY3(resultContainer.x)
        : calculateY4(resultContainer.x);

    resultContainer.d = calculateD(resultContainer.x, resultContainer.y, n);
    resultContainer.maxError = 0;

    for (int i = 0; i < n; i++)
    {
        std::vector<double> xIntermediate
            = isEven
            ? calculateXEven(resultContainer.x[i], resultContainer.x[i + 1], k)
            : calculateXChebyshev(resultContainer.x[i], resultContainer.x[i + 1], k);

        std::vector<double> yIntermediate
            = whatFunction == 1
            ? calculateY1(xIntermediate)
            : whatFunction == 2
            ? calculateY2(xIntermediate)
            : whatFunction == 3
            ? calculateY3(xIntermediate)
            : calculateY4(xIntermediate);

        std::vector<double> yApproxIntermediate = calculateYApprox(resultContainer.d, resultContainer.x, xIntermediate, yIntermediate, n, k);
        std::vector<double> errorsIntermediate = calculateErrors(yIntermediate, yApproxIntermediate, k);

        resultContainer.xExtra.insert(resultContainer.xExtra.end(), xIntermediate.begin() + (i? 1 : 0), xIntermediate.end());
        resultContainer.yExtra.insert(resultContainer.yExtra.end(), yIntermediate.begin() + (i ? 1 : 0), yIntermediate.end());
        resultContainer.yApproxExtra.insert(resultContainer.yApproxExtra.end(), yApproxIntermediate.begin() + (i ? 1 : 0), yApproxIntermediate.end());
        resultContainer.errors.insert(resultContainer.errors.end(), errorsIntermediate.begin() + (i ? 1 : 0), errorsIntermediate.end());
        resultContainer.maxError = calculateMaxError(errorsIntermediate, resultContainer.maxError);
    }

    return resultContainer;
}

std::vector<double> InterpolationController::calculateXEven(double a, double b, int n)
{
    std::vector<double> x;

    for (int i = 0; i <= n; i++)
    {
        x.emplace_back(a + (b - a) * static_cast<double>(i) / n);
    }

    return x;
}

std::vector<double> InterpolationController::calculateXChebyshev(double a, double b, int n)
{
    std::vector<double> x;

    for (int i = 0; i <= n; i++)
    {
        x.emplace_back((a + b) / 2.0 - (b - a) / 2.0 * cos((2.0 * i + 1.0) / (2.0 * n + 2.0) * std::numbers::pi));
    }

    return x;
}

std::vector<double> InterpolationController::calculateY1(std::vector<double> x)
{
    std::vector<double> y;

    for (double node : x)
    {
        y.emplace_back(2 + node - 3 * std::pow(node, 2) + std::pow(node, 3));
    }

    return y;
}

std::vector<double> InterpolationController::calculateY2(std::vector<double> x)
{
    std::vector<double> y;

    for (double node : x)
    {
        y.emplace_back(std::cos(3 * node));
    }

    return y;
}

std::vector<double> InterpolationController::calculateY3(std::vector<double> x)
{
    std::vector<double> y;

    for (double node : x)
    {
        if (std::pow(node, 2) == 0)
        {
            y.emplace_back(std::numeric_limits<double>::infinity());
        }
        else
        {
            y.emplace_back(1.0 / (std::pow(node, 2)));
        }
    }

    return y;
}

std::vector<double> InterpolationController::calculateY4(std::vector<double> x)
{
    std::vector<double> y;

    for (double node : x)
    {
        y.emplace_back(std::abs(node));
    }

    return y;
}

std::vector<std::vector<double>> InterpolationController::calculateD(std::vector<double> x, std::vector<double> y, int n)
{
    std::vector<std::vector<double>> d(n + 1);
    for (int i = 0; i <= n; i++)
    {
        d[i].resize(n - i + 1);
    }

    for (int i = 0; i <= n; i++)
    {
        d[i][0] = y[i];
    }

    for (int i = 1; i <= n; i++)
    {
        for (int j = 0; j <= n - i; j++)
        {
            if (std::abs(x[j] - x[j + i]) == 0)
            {
                d[j][i] = std::numeric_limits<double>::infinity();
            }
            else
            {
                d[j][i] = (d[j][i - 1] - d[j + 1][i - 1]) / (x[j] - x[j + i]);
            }
        }
    }

    return d;
}

std::vector<double> InterpolationController::calculateYApprox(std::vector<std::vector<double>> d, std::vector<double> xOrig, std::vector<double> x, std::vector<double> y, int n, int k)
{
    std::vector<double> yApprox;

    for (int i = 0; i <= k; i++)
    {
        double approximationPart = 1;
        double approximation = d[0][0];

        for (int j = 1; j <= n; j++)
        {
            approximationPart = approximationPart * (x[i] - xOrig[j - 1]);
            approximation = approximation + (d[0][j] * approximationPart);
        }

        yApprox.emplace_back(approximation);
    }

    return yApprox;
}

std::vector<double> InterpolationController::calculateErrors(std::vector<double> y, std::vector<double> yApprox, int n)
{
    std::vector<double> errors;

    for (int i = 0; i <= n; i++)
    {
        errors.emplace_back(std::abs(y[i] - yApprox[i]));
    }

    return errors;
}

double InterpolationController::calculateMaxError(std::vector<double> errors, double maxError)
{
    double maxErrorIntermediate = *std::max_element(errors.begin(), errors.end());

    if (maxErrorIntermediate > maxError)
    {
        maxError = maxErrorIntermediate;
    }

    return maxError;
}