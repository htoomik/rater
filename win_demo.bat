call %appdata%/npm/tsc -p Rater.Api
dotnet build
dotnet test Rater.Tests
cd Rater.Api
dotnet run --launch-profile Rater.Api 
cd ..