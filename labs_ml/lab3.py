import numpy as np
import pandas as pd
from sklearn.compose import ColumnTransformer
from sklearn.ensemble import RandomForestRegressor
from sklearn.impute import SimpleImputer
from sklearn.metrics import mean_absolute_error
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import train_test_split
from sklearn.pipeline import Pipeline
from sklearn.preprocessing import OneHotEncoder
from xgboost import XGBRegressor

df = pd.read_csv("penguins.csv")

y = df["species"].apply(lambda element: 0 if element == "Adelie" else 1 if element == "Gentoo" else 2)
x = df[["island", "bill_length_mm", "bill_depth_mm", "flipper_length_mm", "body_mass_g", "sex", "year"]]

numeric_features = ["bill_length_mm", "bill_depth_mm", "flipper_length_mm", "body_mass_g", "year"]
numeric_transformer = SimpleImputer()

categorical_features = ["island", "sex"]
categorical_imputer = SimpleImputer(strategy='most_frequent')
categorical_encoder = OneHotEncoder()
categorical_transformer = Pipeline(
    steps=[
        ('imputer', categorical_imputer),
        ('encoder', categorical_encoder)
    ]
)

preprocessor = ColumnTransformer(
    transformers=[
        ("num", numeric_transformer, numeric_features),
        ("cat", categorical_transformer, categorical_features),
    ]
)

random_forest_pipeline = Pipeline(
    steps=[
        ("preprocessor", preprocessor),
        ("classifier", RandomForestRegressor(max_depth=50))
    ]
)

print("Error of RandomForestRegressor: " + str(np.mean(cross_val_score(random_forest_pipeline, x, y))))

x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.3)

x_g_b_regressor_pipeline = Pipeline(
    steps=[
        ("preprocessor", preprocessor),
        ("classifier", XGBRegressor())
    ]
)

x_g_b_regressor_pipeline.fit(x_train, y_train)
y_pred = x_g_b_regressor_pipeline.predict(x_test)
print("Error of XGBRegressor: " + str(mean_absolute_error(y_test, y_pred)))
