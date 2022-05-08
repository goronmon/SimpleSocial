namespace SimpleSocial.Data;

public interface ICreateDate
{
	DateTime CreateDate { get; set; }
}

public interface IModifiedDate
{
	DateTime ModifiedDate { get; set; }
}

public interface IDateCreateAndModified: ICreateDate, IModifiedDate
{
}