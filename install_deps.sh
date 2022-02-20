wget https://cdn.plot.ly/plotly-2.4.2.min.js
wget https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js
wget https://raw.githubusercontent.com/marcj/css-element-queries/master/src/ResizeSensor.js
wget https://raw.githubusercontent.com/marcj/css-element-queries/master/src/ElementQueries.js
cp plotly-2.4.2.min.js   ./src-tauri/dev/plotly.js
cp jquery.min.js  ./src-tauri/dev/jquery.js
cp ResizeSensor.js ./src-tauri/dev/ResizeSensor.js
cp ElementQueries.js ./src-tauri/dev/ElementQueries.js
