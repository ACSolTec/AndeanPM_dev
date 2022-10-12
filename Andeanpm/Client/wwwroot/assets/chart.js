function renderChartApex(options, id) {
  var chart = new ApexCharts(document.querySelector("#"+id), options);
  
  chart.render();
    
}
