using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.ValueObjects
{
    public class Verification : ValueObject
    {
        public Verification() { } // necessário para o EF

        public Verification(string code, DateTime? expiresAt)
        {
            Code = code;
            ExpiresAt = expiresAt;
        }

        public string Code { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }
        public bool IsActive => VerifiedAt == null && ExpiresAt > DateTime.UtcNow;

        public void Verify(string code)
        {
            if (ExpiresAt != null && ExpiresAt < DateTime.UtcNow)
                throw new InvalidOperationException("Verification has expired.");

            if (!string.Equals(code?.Trim(), Code?.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new InvalidOperationException("Invalid verification code.");

            VerifiedAt = DateTime.UtcNow;
            ExpiresAt = null;
        }
    }

}