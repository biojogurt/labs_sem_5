import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_absolute_error
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeRegressor

pd.set_option('display.max_rows', 500)
pd.set_option('display.max_columns', 10)
pd.set_option('display.width', 120)

df = pd.read_csv("penguins_no_nulls.csv")

y = df["species"].apply(lambda element: 0 if element == "Adelie" else 1 if element == "Gentoo" else 2)
x = df[["bill_length_mm", "bill_depth_mm", "flipper_length_mm", "body_mass_g"]]

print("---Data---")
print("Dataset:\n" + df.to_string() + "\n")
print("Length: " + str(df.shape[0]) + "\n")
print("Statistics:\n" + str(x.describe()) + "\n")

x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.3)

print("---Decision Tree Regressor---")
for depth in [5, 50, 500]:
    dtr = DecisionTreeRegressor(max_depth=depth)
    dtr.fit(x_train, y_train)
    y_pred = dtr.predict(x_test)
    print("Depth: " + str(depth))
    print("Error: " + str(mean_absolute_error(y_test, y_pred)) + "\n")

print("---Random Forest Regressor---")
for depth in [5, 50, 500]:
    dtr = RandomForestRegressor(max_depth=depth)
    dtr.fit(x_train, y_train)
    y_pred = dtr.predict(x_test)
    print("Depth: " + str(depth))
    print("Error: " + str(mean_absolute_error(y_test, y_pred)) + "\n")
