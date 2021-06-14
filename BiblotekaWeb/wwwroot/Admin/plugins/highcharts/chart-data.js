$(document).ready(function () {

    var options = {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Statistikat e librave për kategori',
            style: {
                fontFamily: 'Poppins'
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.y}</b>',
            style: {
                fontFamily: 'Poppins'
            }
        },
        credits: {
            enabled: false
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.y} libra',
                    style: {
                        fontFamily: 'Poppins'
                    }
                }
            }
        },
        series: []
    }
    
    
   $.ajax({
       url: "ballina/getdata",
       method: "GET",
       dataType: "json",
       success: function (data) {
           const huazimet = data.huazimetData;
           const kthimet = data.kthimetData;
           const kategorite = data.kategoriteData;
           const mapDatas = data.mapDatas;
           var data = [];
           mapDatas.forEach(element => {
               data.push({"hc-key": element.kodi, value: element.numri});
           });
           Highcharts.chart('highchart-bar', {
               chart: {
                   type: 'column'
               },
               title: {
                   text: 'Statistika e Biblotekës',
                   style: {
                       fontFamily: 'Poppins'
                   }
               },
               subtitle: {
                   text: 'Statistikat Mujore të Bibliotekës',
                   style: {
                       fontFamily: 'Poppins'
                   }
               },
               xAxis: {
                   categories: [
                       'Jan',
                       'Feb',
                       'Mar',
                       'Apr',
                       'May',
                       'Jun',
                       'Jul',
                       'Aug',
                       'Sep',
                       'Oct',
                       'Nov',
                       'Dec'
                   ],
                   crosshair: true
               },
               yAxis: {
                   min: 0,
                   title: {
                       text: 'Regjistrime'
                   }
               },
               tooltip: {
                   headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                   pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                       '<td style="padding:0"><b>{point.y:.1f} {series.name}</b></td></tr>',
                   footerFormat: '</table>',
                   shared: true,
                   useHTML: true
               },
               plotOptions: {
                   column: {
                       pointPadding: 0.2,
                       borderWidth: 0
                   }
               },
               series: [{
                   name: 'Huazime',
                   data: huazimet

               }, {
                   name: 'Kthime',
                   data: kthimet 
               }]
           });
           
           Highcharts.mapChart('map', {
               chart: {
                   map: 'countries/kv/kv-all',
                   style: {
                       marginTop: 0
                   }
               },

               title: {
                   text: 'Numri i klientëve për qytet',
                   style: {
                       fontFamily: 'Poppins',
                       paddingTop: -150,
                   }
               },

               mapNavigation: {
                   enabled: true,
                   buttonOptions: {
                       verticalAlign: 'bottom'
                   }
               },

               colorAxis: {
                   min: 0
               },

               series: [{
                   data: data,
                   name: 'Numri Klientëve',
                   states: {
                       hover: {
                           color: '#BADA55'
                       }
                   },
                   dataLabels: {
                       enabled: true,
                       format: '{point.name}'
                   }
               }]
           });

           var series = {
               name: 'Numri',
               colorByPoint: true,
               data: []
           }
           
           kategorite.forEach(kategori => {
               series.data.push({name: kategori.emertimi, y: kategori.librat});
           });
           
           // for (var i = 0; i < kategorite.length; i++){
           //     series.data.push({name: kategorite[i].emertimi, y: kategorite[i].librat});
           // }
           
           options.series.push(series);
           window.Highcharts.chart('pie',options);
           
       }
   })
})


