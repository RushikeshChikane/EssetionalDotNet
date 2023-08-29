using System;

namespace RefactoringGuru.DesignPatterns.Adapter.Conceptual;

// The Target defines the domain-specific interface used by the client code.
public interface ITarget
{
    string GetRequest();
}


