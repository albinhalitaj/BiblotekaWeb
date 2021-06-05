$(document).ready(function () {
    
   $.ajax({
       url: "ballina/getdata",
       method: "GET",
       dataType: "json",
       success: function (data) {
           var huazimet = data.huazimetData;
           var kthimet = data.kthimetData;
           console.log(data);
           console.log(kthimet);
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
       }
   }) 
})


