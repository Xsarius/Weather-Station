/// Sensor class
class Sensor {
  constructor(name, value) {
    this.name = name;
    this.value = value;
  }
}
///

var dataTest = new String();

var sensor = new Array();

for (var x = 0; x < 6; x++) {
  sensor[x] = new Sensor("sensor" + x, 0);

  dataTest += sensor[x].name; // Headers in the File

  dataTest += "\t"; // File formating
}

dataTest += "\n"; // File formating

/// Refresh of data
setInterval(updateData, 750);

function updateData() {
  for (var x = 1; x < 6; x++) {
    // Update values
    sensor[x].value = (Math.random() * (100 - 0)).toFixed(4);

    dataTest += sensor[x].value;

    dataTest += "\t";

    // Update table
    document.getElementById("sensor" + x).innerHTML = sensor[x].name;
    document.getElementById("sensor" + x + "value").innerHTML = sensor[x].value;
  }
  dataTest += "\n";
}
///

var FileSaver = require('file-saver');

var dataFile = new Blob([dataTest], {
  type: "text/plain;charset=utf-8",
});

FileSaver.saveAs(dataFile);
