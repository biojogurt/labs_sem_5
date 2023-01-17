import matplotlib.pyplot as plt
import numpy as np
from scipy.integrate import solve_bvp

np.set_printoptions(linewidth=np.nan)

A = 0.2
L = 2
B = L / 2
y0 = 0


def ode(x, y):
    return np.array([y[1], A * (B - abs(x - B)) * (1 + y[1] ** 2) ** (3 / 2)])


def bc(ya, yb):
    return np.array([ya[0] - y0, yb[0] - y0])


if __name__ == "__main__":
    steps = int(L * 100 + 1)
    x = np.linspace(0, L, steps)
    y_estimate = np.zeros((2, steps))

    sol = solve_bvp(ode, bc, x, y_estimate)

    print(sol.x)
    print(sol.y)

    plt.plot(sol.x, sol.y[0])

    locs, labels = plt.yticks()
    closest_to_B = np.abs(sol.x - B).argmin()
    locs = np.append(locs, sol.y[0][closest_to_B])
    plt.yticks(locs)

    plt.xlim([0, L])
    plt.xlabel('x')
    plt.ylabel('y')
    plt.grid()
    plt.tight_layout()
    plt.show()
