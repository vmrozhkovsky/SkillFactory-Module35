using ADO_Dll;

var connector = new MainConnector();

var result = connector.ConnectAsync();

if (result.Result) {
    Console.WriteLine("Подключено успешно!");
} 
else {
    Console.WriteLine("Ошибка подключения!");
}