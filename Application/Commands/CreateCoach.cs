using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateCoach
    {
        public record CreateCoachCommand(Guid TrainId, string CoachNo, int Capacity, BookingClass BookingClass) : IRequest<BaseResponse<CreateCoachResponse>>;
        public class CreateCoachCommandValidator : AbstractValidator<CreateCoachCommand>
        {
            public CreateCoachCommandValidator()
            {
                RuleFor(x => x.TrainId)
                    .NotEmpty()
                    .WithMessage("Train ID is required");

                RuleFor(x => x.CoachNo)
                    .NotEmpty()
                    .WithMessage("Coach number is required")
                    .MaximumLength(50)
                    .WithMessage("Coach number cannot exceed 50 characters");

                RuleFor(x => x.Capacity)
                    .GreaterThan(0)
                    .WithMessage("Capacity must be greater than 0")
                    .LessThanOrEqualTo(60)
                    .WithMessage("Capacity cannot exceed 60");

                RuleFor(x => x.BookingClass)
                    .IsInEnum()
                    .WithMessage("Invalid booking class");
            }
        }
        public class CreateCoachHandler : IRequestHandler<CreateCoachCommand, BaseResponse<CreateCoachResponse>>
        {
            private readonly ICoachRepository _coachRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICurrentUser _currentUser;
            public CreateCoachHandler(ICoachRepository coachRepository, IUnitOfWork unitOfWork, ICurrentUser currentUser)
            {
                _coachRepository = coachRepository;
                _unitOfWork = unitOfWork;
                _currentUser = currentUser;
            }
            public async Task<BaseResponse<CreateCoachResponse>> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
            {
                var coachExist = await _coachRepository.IsExist(request.TrainId, request.CoachNo);
                if (coachExist) throw new Exception($"{request.CoachNo} already exist");
                var coach = new Coach
                {
                    TrainId = request.TrainId,
                    CoachNo = request.CoachNo,
                    Capacity = request.Capacity,
                    BookingClass = request.BookingClass,
                    CreatedBy = _currentUser.GetCurrentUser().ToString()
                };
                await _coachRepository.AddAsync(coach);
                await _unitOfWork.SaveAsync();
                return BaseResponse<CreateCoachResponse>.Success(coach.Adapt<CreateCoachResponse>(), "Coach created successfully");
            }
        }

        public record CreateCoachResponse(Guid Id, string CoachNo);
    }
}
