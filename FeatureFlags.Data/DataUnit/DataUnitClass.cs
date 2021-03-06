using System.Data.Entity;
using FeatureFlags.Data.Models;
using FeatureFlags.Data.Interfaces;
using FeatureFlags.Data.Repository;

namespace FeatureFlags.Data
{
	// Note - This is autogenerated code.
	public class DataUnit : IDataUnit
    {
	    private readonly DataContext _context;
		public DataUnit()
		{
			_context = new DataContext();
		}

		public DataUnit(DbContext context)
		{
			_context = context as DataContext;
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}

		
		private EFGenericRepository<FeatureFlag> _FeatureFlagRepository;
		public IGenericRepository<FeatureFlag> FeatureFlagRepository 
		{ 
			get 
			{ 
				return (_FeatureFlagRepository ?? (_FeatureFlagRepository = new EFGenericRepository<FeatureFlag>(_context))); 
			} 
			set
			{
				_FeatureFlagRepository = value as EFGenericRepository<FeatureFlag>;
			}
		}
			
		private EFGenericRepository<FeatureRole> _FeatureRoleRepository;
		public IGenericRepository<FeatureRole> FeatureRoleRepository 
		{ 
			get 
			{ 
				return (_FeatureRoleRepository ?? (_FeatureRoleRepository = new EFGenericRepository<FeatureRole>(_context))); 
			} 
			set
			{
				_FeatureRoleRepository = value as EFGenericRepository<FeatureRole>;
			}
		}
			
		private EFGenericRepository<FeatureRoleUser> _FeatureRoleUserRepository;
		public IGenericRepository<FeatureRoleUser> FeatureRoleUserRepository 
		{ 
			get 
			{ 
				return (_FeatureRoleUserRepository ?? (_FeatureRoleUserRepository = new EFGenericRepository<FeatureRoleUser>(_context))); 
			} 
			set
			{
				_FeatureRoleUserRepository = value as EFGenericRepository<FeatureRoleUser>;
			}
		}
			
		private EFGenericRepository<FeatureStateRole> _FeatureStateRoleRepository;
		public IGenericRepository<FeatureStateRole> FeatureStateRoleRepository 
		{ 
			get 
			{ 
				return (_FeatureStateRoleRepository ?? (_FeatureStateRoleRepository = new EFGenericRepository<FeatureStateRole>(_context))); 
			} 
			set
			{
				_FeatureStateRoleRepository = value as EFGenericRepository<FeatureStateRole>;
			}
		}
			
		private EFGenericRepository<FeatureState> _FeatureStateRepository;
		public IGenericRepository<FeatureState> FeatureStateRepository 
		{ 
			get 
			{ 
				return (_FeatureStateRepository ?? (_FeatureStateRepository = new EFGenericRepository<FeatureState>(_context))); 
			} 
			set
			{
				_FeatureStateRepository = value as EFGenericRepository<FeatureState>;
			}
		}
			
		private EFGenericRepository<FeatureFeedback> _FeatureFeedbackRepository;
		public IGenericRepository<FeatureFeedback> FeatureFeedbackRepository 
		{ 
			get 
			{ 
				return (_FeatureFeedbackRepository ?? (_FeatureFeedbackRepository = new EFGenericRepository<FeatureFeedback>(_context))); 
			} 
			set
			{
				_FeatureFeedbackRepository = value as EFGenericRepository<FeatureFeedback>;
			}
		}
	}
}
