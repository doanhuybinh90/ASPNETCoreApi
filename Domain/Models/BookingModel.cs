using Domain.DTOs.Administrator;
using Domain.DTOs.Bookings;
using Domain.DTOs.Visitor;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BookingModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _description;

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		private decimal _price;

		public decimal Price
		{
			get { return _price; }
			set { _price = value; }
		}

		private Administrator _administrator;

		public Administrator Administrator
		{
			get { return _administrator; }
			set { _administrator = value; }
		}

		private Visitor _visitor;

		public Visitor Visitor
		{
			get { return _visitor; }
			set { _visitor = value; }
		}

		private DateTime _createAt;

		public DateTime CreateAt
		{
			get { return _createAt; }
			set {

				_createAt = value == null ? DateTime.UtcNow : value;
			}
		}

		private DateTime _updateAt;

		public DateTime UpdateAt
		{
			get { return _updateAt; }
			set { _updateAt = value == null ? DateTime.UtcNow : value; }
		}






	}
}
