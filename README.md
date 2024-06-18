# 3D-Data Viz with Unity and NYC OpenData
<img width="677" alt="Screenshot 2024-06-13 224226" src="https://github.com/cgshony/3D-Data-Viz/assets/129407856/1799b956-a8c9-4714-86a9-44990909435f">

This project visualizes NYC taxi trip data using Unity3D. It provides a 3D representation of taxi pickups and drop-offs on a map of New York City. The project aims to demonstrate how to parse and visualize geospatial data within a 3D game engine.


## Features
- **Data Parsing:** Reads taxi trip data from a JSON file.
- **3D Visualization:** Uses Unity to visualize pickup and drop-off points as spheres in a 3D space.
- **Dynamic Scaling:** Adjusts the visualization scale for better representation within the scene.

## Prerequisites
- Unity 2019.4 or higher
- Basic knowledge of C# and Unity
- NYC Taxi trip data in JSON format

# Project Description:

Data Source
The data used in this project is sourced from: https://data.cityofnewyork.us/Transportation/2009-Yellow-Taxi-Trip-Data/f9tw-8p66/about_data
Specifically, I utilized the 2009 Yellow Taxi Trip Data between 12th-13th July 2009 to rest and dimplify the calculations. The *.csv file provides detailed information on individual taxi trips, including pickup and drop-off times and locations, trip distances, and fare amounts.

# Data Preparation
The data was downloaded as a CSV file and then processed in python using Pandas to fit the requirements of the Unity project. Below are the detailed steps taken to prepare and utilize the data. Custom column names were added to ensure clarity and consistency.

Data Conversion to JSON:
Using Python, the cleaned Data was then converted to a JSON format suitable for loading into Unity.

# Unity Implementation
1. Prefabs. Two sphere prefabs were created to represent pickup and drop-off points.
   
<img width="499" alt="Screenshot 2024-06-13 144945" src="https://github.com/cgshony/3D-Data-Viz/assets/129407856/63e34e0f-7329-4006-85c1-7740b86349e5">

  
2. TaxiDataParser Script. The script is responsible for loading the JSON data, parsing it, and instantiating the prefabs at the correct locations in the Unity scene.
The script also draws lines between pickup and drop-off points to visualize the paths of taxi trips.
