# What does this app do?
- Allows you to list and rate your skills 

# What for?
- For me to try out .NET Core, Angular 4 etc
- Demonstrate those skills to others

# Try it out
On Windows: running `win_demo.bat` may help.  
If it doesn't, it's probably due to some path weirdness, and you'll have to build and run things manually using something like this:
```
tsc -p Rater.Api
dotnet build
dotnet test Rater.Tests
dotnet run
```

Then use your favourite browser to navigate to either [http://localhost:5000/index.html](http://localhost:5000/index.html) for the Angular version, or to [http://localhost:5000/](http://localhost:5000/) for the ASP.NET MVC version.

# Why the two separate front end solutions?
Only to demonstrate that I can work in both Angular and ASP.NET MVC. The two front ends are totally redundant and would never coexist in a real application. However they do work together without conflict and are fully usable in parallel.

# API endpoints
GET  
`/skills`  
`/skills/5`  

PUT  
`/skills/5`   (update, overwriting all existing values)  

POST  
`/skills`     (create)  
`/skills/5`   (update, ignoring null properties)  

DELETE  
`/skills/5`

# Screenshot
![Screenshot](https://raw.githubusercontent.com/htoomik/rater/master/screenshot.png)
