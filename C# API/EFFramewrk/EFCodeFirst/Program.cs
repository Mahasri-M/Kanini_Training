using EFCodeFirst;

class Program
{
    public static void Main(string[] args)
    {
        CRUDOpera crud= new CRUDOpera();
        // crud.InsertRecordsInStudentEntity();
        //crud.InsertRecordsInCourseEntity();
        //crud.UpdateRecordsInStudentEntity();
        //crud.DeleteRecordsInStudentEntity();
        crud.ReadDataFromStudentEntity(raj);
    }
}