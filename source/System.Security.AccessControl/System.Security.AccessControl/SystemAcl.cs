using System.Security.Principal;

namespace System.Security.AccessControl;

public sealed class SystemAcl : CommonAcl
{
	public SystemAcl(bool isContainer, bool isDS, int capacity)
		: this(isContainer, isDS, isDS ? GenericAcl.AclRevisionDS : GenericAcl.AclRevision, capacity)
	{
	}

	public SystemAcl(bool isContainer, bool isDS, byte revision, int capacity)
		: base(isContainer, isDS, revision, capacity)
	{
	}

	public SystemAcl(bool isContainer, bool isDS, RawAcl rawAcl)
		: this(isContainer, isDS, rawAcl, trusted: false)
	{
	}

	internal SystemAcl(bool isContainer, bool isDS, RawAcl rawAcl, bool trusted)
		: base(isContainer, isDS, rawAcl, trusted, isDacl: false)
	{
	}

	public void AddAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
	{
		CheckFlags(inheritanceFlags, propagationFlags);
		AddQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
	}

	public void SetAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
	{
		CheckFlags(inheritanceFlags, propagationFlags);
		SetQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
	}

	public bool RemoveAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
	{
		return RemoveQualifiedAces(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), saclSemantics: true, ObjectAceFlags.None, Guid.Empty, Guid.Empty);
	}

	public void RemoveAuditSpecific(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags)
	{
		RemoveQualifiedAcesSpecific(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), ObjectAceFlags.None, Guid.Empty, Guid.Empty);
	}

	public void AddAudit(SecurityIdentifier sid, ObjectAuditRule rule)
	{
		AddAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
	}

	public void AddAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
	{
		if (!base.IsDS)
		{
			throw new InvalidOperationException(System.SR.InvalidOperation_OnlyValidForDS);
		}
		CheckFlags(inheritanceFlags, propagationFlags);
		AddQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
	}

	public void SetAudit(SecurityIdentifier sid, ObjectAuditRule rule)
	{
		SetAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
	}

	public void SetAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
	{
		if (!base.IsDS)
		{
			throw new InvalidOperationException(System.SR.InvalidOperation_OnlyValidForDS);
		}
		CheckFlags(inheritanceFlags, propagationFlags);
		SetQualifiedAce(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
	}

	public bool RemoveAudit(SecurityIdentifier sid, ObjectAuditRule rule)
	{
		return RemoveAudit(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
	}

	public bool RemoveAudit(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
	{
		if (!base.IsDS)
		{
			throw new InvalidOperationException(System.SR.InvalidOperation_OnlyValidForDS);
		}
		return RemoveQualifiedAces(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), saclSemantics: true, objectFlags, objectType, inheritedObjectType);
	}

	public void RemoveAuditSpecific(SecurityIdentifier sid, ObjectAuditRule rule)
	{
		RemoveAuditSpecific(rule.AuditFlags, sid, rule.AccessMask, rule.InheritanceFlags, rule.PropagationFlags, rule.ObjectFlags, rule.ObjectType, rule.InheritedObjectType);
	}

	public void RemoveAuditSpecific(AuditFlags auditFlags, SecurityIdentifier sid, int accessMask, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, ObjectAceFlags objectFlags, Guid objectType, Guid inheritedObjectType)
	{
		if (!base.IsDS)
		{
			throw new InvalidOperationException(System.SR.InvalidOperation_OnlyValidForDS);
		}
		RemoveQualifiedAcesSpecific(sid, AceQualifier.SystemAudit, accessMask, GenericAce.AceFlagsFromAuditFlags(auditFlags) | GenericAce.AceFlagsFromInheritanceFlags(inheritanceFlags, propagationFlags), objectFlags, objectType, inheritedObjectType);
	}
}
