public interface INote
{
    void Initialize(NoteProps noteProps);
    double JustTime {get;}
    void DestroyMyself();
}