#include "InterpolationController.h"
#include <algorithm>
#include <functional>
#include <numbers>
#include <stdexcept>

InterpolationController::InterpolationController(long a, long b, size_t n, size_t k) : a(a), b(b), n(n), k(k)
{}

ResultContainer InterpolationController::calculate(int whatFunction, bool isEven)
{
    ResultContainer resultContainer;

    resultContainer.x = calculateX(a, b, n, isEven);
    resultContainer.y = calculateY(resultContainer.x, whatFunction);
    resultContainer.d = calculateD(resultContainer.x, resultContainer.y, n);

    std::vector<double> endConditions = calculateEndConditions(resultContainer.x, whatFunction);
    std::vector<double> h = calculateH(resultContainer.x);
    std::vector<double> M = calculateM(h, resultContainer.x, resultContainer.d, endConditions);

    resultContainer.maxError = 0;

    for (int i = 0; i < n; i++)
    {
        std::vector<double> xIntermediate = calculateX(resultContainer.x[i], resultContainer.x[i + 1], k, isEven);
        std::vector<double> yIntermediate = calculateY(xIntermediate, whatFunction);
        std::vector<double> yApproxIntermediate = calculateYApprox(h, M, resultContainer.x, resultContainer.y, xIntermediate, i, k);
        std::vector<double> errorsIntermediate = calculateErrors(yIntermediate, yApproxIntermediate, k);

        resultContainer.xExtra.insert(resultContainer.xExtra.end(), xIntermediate.begin() + (i ? 1 : 0), xIntermediate.end());
        resultContainer.yExtra.insert(resultContainer.yExtra.end(), yIntermediate.begin() + (i ? 1 : 0), yIntermediate.end());
        resultContainer.yApproxExtra.insert(resultContainer.yApproxExtra.end(), yApproxIntermediate.begin() + (i ? 1 : 0), yApproxIntermediate.end());
        resultContainer.errors.insert(resultContainer.errors.end(), errorsIntermediate.begin() + (i ? 1 : 0), errorsIntermediate.end());

        resultContainer.maxError = calculateMaxError(errorsIntermediate, resultContainer.maxError);
    }

    return resultContainer;
}

std::vector<double> InterpolationController::calculateX(double a, double b, int n, bool isEven)
{
    return isEven
        ? calculateXEven(a, b, n)
        : calculateXChebyshev(a, b, n);
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

std::vector<double> InterpolationController::calculateY(std::vector<double> x, int whatFunction)
{
    return whatFunction == 1
        ? calculateY1(x)
        : whatFunction == 2
        ? calculateY2(x)
        : whatFunction == 3
        ? calculateY3(x)
        : calculateY4(x);
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
        y.emplace_back(std::abs(node) == 0
            ? std::numeric_limits<double>::infinity()
            : 1.0 / std::pow(node, 2));
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

std::vector<double> InterpolationController::calculateEndConditions(std::vector<double> x, int whatFunction)
{
    return whatFunction == 1
        ? calculateEndConditions1(x)
        : whatFunction == 2
        ? calculateEndConditions2(x)
        : whatFunction == 3
        ? calculateEndConditions3(x)
        : calculateEndConditions4(x);
}

std::vector<double> InterpolationController::calculateEndConditions1(std::vector<double> x)
{
    std::vector<double> M;

    M.emplace_back(6 * x.front() - 6);
    M.emplace_back(6 * x.back() - 6);

    return M;
}

std::vector<double> InterpolationController::calculateEndConditions2(std::vector<double> x)
{
    std::vector<double> M;

    M.emplace_back(-9 * std::cos(3 * x.front()));
    M.emplace_back(-9 * std::cos(3 * x.back()));

    return M;
}

std::vector<double> InterpolationController::calculateEndConditions3(std::vector<double> x)
{
    std::vector<double> M;

    M.emplace_back(std::abs(x.front()) == 0
        ? std::numeric_limits<double>::infinity()
        : 6.0 / std::pow(x.front(), 4));

    M.emplace_back(std::abs(x.back()) == 0
        ? std::numeric_limits<double>::infinity()
        : 6.0 / std::pow(x.back(), 4));

    return M;
}

std::vector<double> InterpolationController::calculateEndConditions4(std::vector<double> x)
{
    std::vector<double> M;

    M.emplace_back(0);
    M.emplace_back(0);

    return M;
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

std::vector<double> InterpolationController::calculateH(std::vector<double> x)
{
    std::vector<double> h;

    for (int i = 1; i < x.size(); i++)
    {
        h.emplace_back(x[i] - x[i - 1]);
    }

    return h;
}

std::vector<double> InterpolationController::calculateM(std::vector<double> h, std::vector<double> x, std::vector<std::vector<double>> d, std::vector<double> endConditions)
{
    std::vector<double> y;
    std::vector<double> a;
    std::vector<double> b;
    std::vector<double> c;

    y.emplace_back(endConditions[0]);
    a.emplace_back(0);
    b.emplace_back(1);
    c.emplace_back(0);

    for (int i = 0; i < x.size() - 2; i++)
    {
        y.emplace_back(12 * d[i][2]);
        a.emplace_back(2 * h[i] / (h[i + 1] + h[i]));
        b.emplace_back(4);
        c.emplace_back(2 * h[i + 1] / (h[i + 1] + h[i]));
    }

    y.emplace_back(endConditions[1]);
    a.emplace_back(0);
    b.emplace_back(1);
    c.emplace_back(0);

    return calculateTridiagonalMatrix(x, a, b, c, y);
}

std::vector<double> InterpolationController::calculateYApprox(std::vector<double> h, std::vector<double> M, std::vector<double> xOrig, std::vector<double> yOrig, std::vector<double> x, int i, int k)
{
    std::vector<double> yApprox;

    for (int j = 0; j <= k; j++)
    {
        double approximation
            = 1.0 / (6.0 * h[i])
            * (M[i] * std::pow(xOrig[i + 1] - x[j], 3)
                + M[i + 1] * std::pow(x[j] - xOrig[i], 3))
            - h[i] / 6.0
            * (M[i] * (xOrig[i + 1] - x[j])
                + M[i + 1] * (x[j] - xOrig[i]))
            + 1.0 / h[i]
            * (yOrig[i] * (xOrig[i + 1] - x[j])
                + yOrig[i + 1] * (x[j] - xOrig[i]));

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

std::vector<double> InterpolationController::calculateTridiagonalMatrix(std::vector<double> x, std::vector<double> a, std::vector<double> b, std::vector<double> c, std::vector<double> d)
{
    if (b[0] == 0)
    {
        throw std::overflow_error("Divide by zero exception");
    }

    c[0] /= b[0];
    d[0] /= b[0];

    for (int i = 1; i < b.size(); i++)
    {
        double denominator = b[i] - a[i] * c[i - 1];
        if (denominator == 0)
        {
            throw std::overflow_error("Divide by zero exception");
        }

        c[i] /= denominator;
        d[i] = (d[i] - a[i] * d[i - 1]) / denominator;
    }

    x[b.size() - 1] = d[b.size() - 1];

    for (int i = b.size() - 2; i >= 0; i--)
    {
        x[i] = d[i] - c[i] * x[i + 1];
    }

    return x;
}