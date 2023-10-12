Cómo registraron la dependencia del ejercicio anterior? 
    1. En el controlador, creo un elemento del tipo IStudentLogic en readonly para uso de la clase.
    2. Luego en el constructor del controlador, paso por parámetro un IStudentLogic que igualo a la variable que cree para la clase.
    3. Se debe agregar la referencia de IBusinessLogic en el controlador
    4. Agregar la referencia en el Program
    -- CÓDIGO --
        -- StudentController
    using PAC.IBusinessLogic; //3
    private readonly IStudentLogic _studentLogic; //1
    public StudentController(IStudentLogic studentLogic) //2
    {
        _studentLogic = studentLogic;
    }
        -- Program.cs
    services.AddScoped<IStudentLogic, StudentLogic>();
Por qué eligieron esa forma de registrarlo? Qué cambiaría en caso de utilizar alguno de los otros dos? 
    Evito hacer un new cada vez de la lógica de negocio. 
    No le doy la responsabilidad al controlador de crear instancias de la lógica de negocio, desacoplo