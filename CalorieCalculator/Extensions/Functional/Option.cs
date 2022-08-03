using System;
using System.Collections.Generic;

namespace CalorieCalculator.Extensions.Functional
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();

        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);
        public abstract Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map);
        public abstract T Reduce(T whenNone);
        public abstract T Reduce(Func<T> whenNone);

        public abstract Option<TNew> OfType<TNew>() where TNew : class;
    }

    public sealed class Some<T> : Option<T>, IEquatable<Some<T>>
    {
        public T Content { get; }

        public Some(T value)
        {
            Content = value;
        }

        public static implicit operator T(Some<T> some) =>
            some.Content;

        public static implicit operator Some<T>(T value) =>
            new Some<T>(value);

        public override Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            map(Content);

        public override Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) =>
            map(Content);

        public override T Reduce(T whenNone) =>
            Content;

        public override T Reduce(Func<T> whenNone) =>
            Content;

        public override Option<TNew> OfType<TNew>() =>
            typeof(T).IsAssignableFrom(typeof(TNew)) ? new Some<TNew>(Content as TNew)
            : new None<TNew>();

        public override string ToString() =>
            $"Some({ContentToString})";

        private string ContentToString =>
            Content?.ToString() ?? "<null>";

        public bool Equals(Some<T> other) =>
            other?.GetType() == typeof(Some<T>) &&
            EqualityComparer<T>.Default.Equals(Content, other.Content);

        public override bool Equals(object obj) =>
            Equals(obj as Some<T>);

        public override int GetHashCode() =>
            Content?.GetHashCode() ?? 0;

        public static bool operator ==(Some<T> a, Some<T> b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(Some<T> a, Some<T> b) => !(a == b);
    }

    public sealed class None<T> : Option<T>, IEquatable<None<T>>, IEquatable<None>
    {
        public override Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            None.Value;

        public override Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) =>
            None.Value;

        public override T Reduce(T whenNone) =>
            whenNone;

        public override T Reduce(Func<T> whenNone) =>
            whenNone();

        public override Option<TNew> OfType<TNew>() => new None<TNew>();

        public override bool Equals(object obj) =>
            !(obj is null) && (obj is None<T> || obj is None);

        public override int GetHashCode() => 0;

        public bool Equals(None<T> other) =>
            other?.GetType() == typeof(None<T>);

        public bool Equals(None other) => true;

        public static bool operator ==(None<T> a, None<T> b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(None<T> a, None<T> b) => !(a == b);

        public override string ToString() => "None";
    }

    public sealed class None : IEquatable<None>
    {
        public static None Value { get; } = new None();

        private None() { }

        public override string ToString() => "None";

        public override bool Equals(object obj) =>
            !(obj is null) && (obj is None || IsGenericNone(obj.GetType()));

        private bool IsGenericNone(Type type) =>
            type.GenericTypeArguments.Length == 1 &&
            typeof(None<>).MakeGenericType(type.GenericTypeArguments[0]) == type;

        public bool Equals(None other) => true;

        public override int GetHashCode() => 0;
    }
}
