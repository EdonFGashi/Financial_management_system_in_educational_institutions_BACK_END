using Financial_management_system_in_educational_institutions_API.Interfaces;

namespace Financial_management_system_in_educational_institutions_API.Multitenancy
{
    public class StaticTenantProvider : ITenantProvider
    {
        private readonly string _schema;

        public StaticTenantProvider(string schema)
        {
            _schema = schema.ToLowerInvariant();
        }

        public string GetSchema() => _schema;

        public string GetMunicipalityName() => _schema;
    }
}
