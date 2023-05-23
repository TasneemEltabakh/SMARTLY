using ChartExample.Models.Chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SMARTLY.Pages.Models;
//public class ChartBundleModel : PageModel
namespace SMARTLY.Pages
{

    public class ChartBundleModel : PageModel
    {
        public ChartJs Chart { get; set; }




        public string ChartJson { get; set; }
        public void OnGet()
        {
            Database db = new Database();
            //List<string> Bundle_Statics = db.BundleCharts();
            // Ref: https://www.chartjs.org/docs/latest/
            var chartData = @"
{
type: 'bar',
responsive: true,
data:
{
labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
datasets: [{
label: 'Favourite Colors Votes',
data: [12, 19, 3, 5, 2, 3],
backgroundColor: [
'rgba(255, 99, 132, 0.2)',
'rgba(54, 162, 235, 0.2)',
'rgba(255, 206, 86, 0.2)',
'rgba(75, 192, 192, 0.2)',
'rgba(153, 102, 255, 0.2)',
'rgba(255, 159, 64, 0.2)'
],
borderColor: [
'rgba(255, 99, 132, 1)',
'rgba(54, 162, 235, 1)',
'rgba(255, 206, 86, 1)',
'rgba(75, 192, 192, 1)',
'rgba(153, 102, 255, 1)',
'rgba(255, 159, 64, 1)'
],
borderWidth: 1
}]
},
options:
{
scales:
{
y: [{
ticks:
{
beginAtZero: true
}
}]
}
}
}"; //end of chartdata
            try
            {
                Chart = JsonConvert.DeserializeObject<ChartJs>(chartData);
                // set up the labels
                //string[] labelsArray = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };
                //string[] labelsArray = Bundle_Statics.ToArray();
              //  Chart.data.labels = labelsArray;
                // set up the dataset
                Dataset dataset = new Dataset();
                Chart.data.datasets[0].label = "";
               // int[] dataArray = Enumerable.Range(1, Bundle_Statics.Count).ToArray();
               // Chart.data.datasets[0].data = dataArray;
                string serializedChart = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception ex)
            {
                // Handle the exception here
            }


        }
    }
}