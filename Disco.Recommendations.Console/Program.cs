using Disco_Recommendations_Console;

// Create single instance of sample data from first line of dataset for model input
PostModel.ModelInput sampleData = new PostModel.ModelInput()
{
    Col0 = 3F,
    Col3 = 1F,
};



Console.WriteLine("Using model to make single prediction -- Comparing actual Col4 with predicted Col4 from sample data...\n\n");


Console.WriteLine($"Col0: {3F}");
Console.WriteLine($"Col3: {1F}");
Console.WriteLine($"Col4: {2F}");


var predictionResult = PostModel.Predict(sampleData);
Console.WriteLine($"\n\nPredicted Col4: {predictionResult.Score}\n\n");

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();

