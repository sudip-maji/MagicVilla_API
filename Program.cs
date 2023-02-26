<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
=======
=======
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers(option=>{
    option.ReturnHttpNotAcceptable=true;
});
// .AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
>>>>>>> 521ccf57076bb568b26d1e2d13fae82ab4d9d017
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
<<<<<<< HEAD
=======
=======
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
>>>>>>> 521ccf57076bb568b26d1e2d13fae82ab4d9d017
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e

app.Run();
=======
<<<<<<< HEAD
﻿
using System;


    System.Console.WriteLine("Enter a number");
    string input1=Console.ReadLine();
    int num1=Convert.ToInt32(input1);
    System.Console.WriteLine("Enter second number");
    string  input2=Console.ReadLine();
    int num2=Convert.ToInt32(input2);
    System.Console.WriteLine("this is the final ans " + num1+num2);
    

=======
<<<<<<< HEAD
﻿// List<string> days=new List<string>();
// days.Add("MONDAY");
// days.Add("TUESDAY");
// days.Add("WEDNESDAY");
// days.Add("THURSDAY");
// days.Add("FRIDAY");
// days.Add("SATURDAY");
// days.Add("SUNDAY");

// foreach(string day in days){
//     System.Console.WriteLine(day);
// }

// var mon=days[0];
// System.Console.WriteLine(mon);

Dictionary<int,string> months=new Dictionary<int, string>();
months.Add(1,"January");
months.Add(2,"February");
months[3]="March";
months.Add(4,"hvashvgjh");
// months.Add(4,"hvash");
months[4]="April";
foreach(var month in months){
    // System.Console.WriteLine($"key : {month.key},value : {month.value}");
    System.Console.WriteLine(month);
   System.Console.WriteLine(month.Key);
    System.Console.WriteLine(month.Value);

}
// var jan=months.TryGetValue(2,out string February);
// System.Console.WriteLine(jan);

if (months.ContainsKey(1)){
months.Remove(1);
}
if (months.ContainsValue("February")){
months.Remove(2);
}

foreach(var month in months){
    // System.Console.WriteLine($"key : {month.key},value : {month.value}");
    System.Console.WriteLine(month);
}


=======
<<<<<<< HEAD
﻿String fullName = "Sudip Maji";
// String phoneNumber = "123-456-7890";


//fullName = fullName.ToUpper();
//fullName = fullName.ToLower();
//Console.WriteLine(fullName);

//phoneNumber = phoneNumber.Replace("-","");
//Console.WriteLine(phoneNumber);

// String userName = fullName.Insert(0,"Mr.");
// Console.WriteLine(userName);

//Console.WriteLine(fullName.Length);

// String firstName = fullName.Substring(0, 6);
//             String lastName = fullName.Substring(6);

//             Console.WriteLine(firstName);
//             Console.WriteLine(lastName);


string m="1,2,3,4,5,6";
foreach(var c in m.Split(",")){
    System.Console.WriteLine(c);
}

string g="1";
int s =Convert.ToInt32(g);
System.Console.WriteLine(s);
=======
<<<<<<< HEAD
﻿int [] arr={2,5,1,7,3,9,67,10};
// Array.Sort(arr);
// foreach (int item in arr){
//     System.Console.WriteLine(item);
// }
// time complexity=nlogn




// Selection sorting 
//best and worst==n**n
//  using System;
//  int []arr = {64,25,12,22,11};
//  int n=arr.Length;
//  for (int i = 0; i < n; i++)
//         {
//             // Find the minimum element in unsorted array
//             int min_idx = i;
//             for (int j = i + 1; j < n; j++)
//                 if (arr[j] < arr[min_idx])
//                     min_idx = j;
 
//             int temp = arr[min_idx];
//             arr[min_idx] = arr[i];
//             arr[i] = temp;
//         }
        // for (int i=0;i<arr.Length;i++){
        //     System.Console.WriteLine(arr[i]);
        // }



//  time complexity=n, n*n
//  insertion sort
int n = arr.Length;
        for (int i = 1; i < n; i++) {
            int current = arr[i];
            int j = i - 1;
 
            while (j >= 0 && arr[j] > current) {
                arr[j + 1] = arr[j];
                j --;
            }
            arr[j + 1] = current;
        }
        for (int i=0;i<arr.Length;i++){
            System.Console.WriteLine(arr[i]);
        }
=======
﻿// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

byte number =2;
Console.WriteLine(number);

List<string> cars=new List<string>();
cars.Add("Maruti");
cars.Add("Suzuki");
cars.Add("BMW");
//  for (int i=0;i<cars.Count;i++){
//     System.Console.WriteLine(cars[i]);
//  }
foreach(string car in cars){
    System.Console.WriteLine(car);
}

string[] fruits={"apple","watermelon","grapes","peach","banana"};
foreach(string a in fruits){
    System.Console.WriteLine(a);
}

int[] num={1,2,3,4,5,6,7,8,9};
foreach(int n in num){
    System.Console.WriteLine(n);
}

>>>>>>> d6ddb3805dad68ea8a88e56db32cc6dcffc0d2b3
>>>>>>> a127730f1c4fd04de8e703b8a059c2848abf6b97
>>>>>>> 181501880500b66de71a10fd8c835984f4a6f770
>>>>>>> f5147b8870738626a7fd1fc723e0a7e461038c39
>>>>>>> eb01a5eaa69edd001e3e35f7e0020090d060807a
