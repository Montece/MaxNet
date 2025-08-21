namespace MaxNet.Utility.Attributes;

[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers | ImplicitUseTargetFlags.WithInheritors)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public sealed class PublicApiAttribute : Attribute;