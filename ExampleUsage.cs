/// Examples of using the class OperationResult

///Example 1
protected OperationResult<DataSet> TryParse(Stream inputFile)
{
    (bool status, string message, DataSet result) = _tryParse(inputFile);

    return status ? OperationResult<DataSet>.Success(result)
                  : OperationResult<DataSet>.Fail(message);

}

///Example 2
public OperationResult<ParserBase> GetParser(string fileName)
{
    if(fileName.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase ) )
    {


        return OperationResult<ParserBase>.Success(new CreatorParserWord().Create());


    } else if ( fileName.EndsWith(".xlsx", StringComparison.CurrentCultureIgnoreCase))
    {

        return OperationResult<ParserBase>.Success(new CreatorParserExcel().Create());


    } else
    {

        return OperationResult<ParserBase>.Fail("Тип файла не поддерживаеться.");


    }
}
