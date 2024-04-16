﻿namespace RSAllies.HelperTypes
{
	public class Result
	{
		protected Result(bool isSuccess, Error error)
		{
			switch (isSuccess)
			{
				case true when error != Error.None:
					throw new InvalidOperationException();
				case false when error == Error.None:
					throw new InvalidOperationException();
				default:
					IsSuccess = isSuccess;
					Error = error;
					break;
			}
		}

		public bool IsSuccess { get; }

		public bool IsFailure => !IsSuccess;

		public Error Error { get; }

		public static Result Success() => new(true, Error.None);

		public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

		public static Result Failure(Error error) => new(false, error);

		public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

		public static Result Create(bool condition) => condition ? Success() : Failure(Error.ConditionNotMet);

		public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
	}

}
