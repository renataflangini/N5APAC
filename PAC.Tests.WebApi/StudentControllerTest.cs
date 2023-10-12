namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.BusinessLogic;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic>? _service;
    private StudentController _controller;
    private Student correctStudent;
    private Student incorrectStudent;
    [TestInitialize]
    public void InitTest()
    {
        _service = new Mock<IStudentLogic>(MockBehavior.Strict);
        _controller = new StudentController(_service.Object);
        correctStudent = new Student()
        {
            Id = 1,
            Name = "EstudianteCorrecto"
        };
        incorrectStudent = new Student()
        {
            Id = 2,
            Name = ""
        };
    }

    [TestMethod]
    public void PostStudentOk()
    {
        _service?.Setup(s => s.InsertStudents(It.IsAny<Student>())).Verifiable();

        var result = _controller?.PostStudent(correctStudent!);
        var parsedResult = result as OkObjectResult;
        var statusCode = parsedResult?.StatusCode;

        Assert.AreEqual(200, statusCode);

        _service?.VerifyAll();
    }

    [ExpectedException(typeof(Exception))]
    [TestMethod]
    public void PostStudentFail()
    {
        _service?.Setup(s => s.InsertStudents(null)).Verifiable();

        var result = _controller?.PostStudent(null);
        var parsedResult = result as OkObjectResult;
        var statusCode = parsedResult?.StatusCode;

        Assert.AreEqual(200, statusCode);

        _service?.VerifyAll();
    }
}
