// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var c = new Class1();

//17s
//await c.FritarOvo();
//await c.FazerSuco();
//await c.LavarPanela();

var h1 = c.FritarOvo();
var h2 = c.FazerSuco();
var h3 = c.LavarPanela();


await Task.WhenAll(h1, h2, h3);

Console.ReadLine();