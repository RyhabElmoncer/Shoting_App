using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using E_CommerceWebApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_CommerceWebApplication.Controllers
{
    public class ReservationController : Controller
    {
        private static List<Reservation> reservations = new List<Reservation>();

        // Action pour afficher la liste des réservations
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            return View(reservations);
        }

        // Action pour afficher le formulaire d'ajout de réservation
        public IActionResult Create()
        {
            return View();
        }

        // Action pour traiter l'ajout de réservation
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            reservation.id = reservations.Count + 1;
            reservations.Add(reservation);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        // Action pour afficher le formulaire de modification de réservation
        public IActionResult Edit(int id)
        {
            Reservation reservation = reservations.FirstOrDefault(r => r.id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }
        [Authorize(Roles = "Admin")]

        // Action pour traiter la modification de réservation
        [HttpPost]
        public IActionResult Edit(Reservation reservation)
        {
            Reservation existingReservation = reservations.FirstOrDefault(r => r.id == reservation.id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            existingReservation.name = reservation.name;
            existingReservation.Email = reservation.Email;
            existingReservation.phone = reservation.phone;
            existingReservation.date = reservation.date;

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]

        // Action pour afficher le formulaire de suppression de réservation
        public IActionResult Delete(int id)
        {
            Reservation reservation = reservations.FirstOrDefault(r => r.id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }
        [Authorize(Roles = "Admin")]

        // Action pour traiter la suppression de réservation
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = reservations.FirstOrDefault(r => r.id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservations.Remove(reservation);
            return RedirectToAction("Index");
        }
    }
}
