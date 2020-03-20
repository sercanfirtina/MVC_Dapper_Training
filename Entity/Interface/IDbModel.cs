using Entity.Repository;

namespace Entity.Interface
{
    public interface IDbModel
    {
        AbstractDapperRepo Repository { get; set; }

        void SetId(object id);

        void SetRepository(AbstractDapperRepo dapperRepository);
    }
}
