//@QnSCodeCopy
//MdStart

namespace QnSCommunityCount.Logic.Entities
{
    internal abstract partial class OneToOneObject<TFirst, TFirstEntity, TSecond, TSecondEntity> : IdentityObject
        where TFirst : Contracts.IIdentifiable
        where TSecond : Contracts.IIdentifiable
        where TFirstEntity : IdentityObject, Contracts.ICopyable<TFirst>, TFirst, new()
        where TSecondEntity : IdentityObject, Contracts.ICopyable<TSecond>, TSecond, new()
    {
        public virtual TFirstEntity FirstEntity { get; } = new TFirstEntity();
        public virtual TFirst FirstItem => FirstEntity;

        public virtual TSecondEntity SecondEntity { get; } = new TSecondEntity();
        public virtual TSecond SecondItem => SecondEntity;

        public override int Id { get => FirstEntity.Id; set => FirstEntity.Id = value; }
        public override byte[] RowVersion { get => FirstEntity.RowVersion; set => FirstEntity.RowVersion = value; }
    }
}
//MdEnd
