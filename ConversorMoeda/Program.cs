using ConsultorioOdontologico.util;
using ConversorMoeda.controller;
using ConversorMoeda.presentation;

var controller = new ConversaoController();
var console = new MyConsole();

DataInput.Device = console;
DataOutput.Device = console;

controller.Start();
