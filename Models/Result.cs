namespace Zintegrujemyfin.Models
{
	/// <summary>
	/// Result
	/// </summary>
	public class Result
	{
		public Result()
		{
			Errors = new List<string>();
		}

		/// <summary>
		/// Errors
		/// </summary>
		public List<string> Errors { get; set; }

		/// <summary>
		/// Is Valid
		/// </summary>
		public bool IsValid => !Errors.Any();

		/// <summary>
		/// Add operator
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns></returns>
		public static Result operator +(Result first, Result second) 
		{
			var result = new Result();

			foreach (var error in first.Errors)
			{
				result.Errors.Add(error);
			}

			foreach (var error in second.Errors)
			{
				result.Errors.Add(error);
			}

			return result;
		}
	}
}
