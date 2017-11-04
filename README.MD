# RazHeaderAttribute
## Simple dotnet package for getting values from request headers in a clean way

### **Instructions**
------
Setting up and using this library/package can be done in a few simple steps
1. ### Install from nuget

    You can do this using one of two ways
    *  #### Via nuget package manager console  
    Simply type in the following command in the PM console
    ```
    nuget install raz-header-attribute
    ```
    *  #### Via nuget package manager GUI  
    1. Right click on your solution
    2. click on the nuget package manager
    3. search for raz-header-attribute
    4. install :)

2. ### Add the Attribute close to the controller parameter you wish to bind it to  
    If you're already familiar with binding attributes this will be the simplest step. If you're not, C# has binding attributes that tell the framework where to get parameters specified in your controller from. For example, the `[FromUri]` attribute that tells the framework to pick that parameter from the URI or the `[FromBody]` one that tells the framework to pick the parameter from the request body for post requests.  

    This package makes the attribute `[FromHeader]` available and also lets us specify the name of the header key we need and just like the pre-built attributes, it tries to bind to any primitive data type specified. Here's an example:

      ```C#
        ...
        using RazHeaderAttribute.Attributes;

        [Route("api/{controller}")]
        // Ewa-agoyin with sauce ;)
        public class YamAndBeansController : ApiController 
        {
            ...
            // GET api/yamandbeans
            [HttpGet]
            public IEnumerable<string> Get([FromHeader("page")] int page, [FromHeader("rows")] string row)
            {
                // Print in the debug window to be sure our bound stuff are passed :)
                Debug.WriteLine($"My Debugger!!! Arrrrrggggh!!!!: Rows {rows}, Page {page}");
                ...
            }
        }
      ```
    And with this you're all setup and good. You can star this repo if you found this useful :)
