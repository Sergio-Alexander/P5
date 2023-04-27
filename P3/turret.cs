using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighter
{
    public class Turret : Fighter
    {
        private int failed_requests;
        private int max_failed_requests;
        private bool is_permanently_dead;

        public Turret(ICombat_Unit fighter_artillery, int maxFailedRequests, int minimum_strength, int armament_strength, int attack_range, int fighter_row, int fighter_col) : base(fighter_artillery, minimum_strength, armament_strength, attack_range, fighter_row, fighter_col)
        {
            max_failed_requests = maxFailedRequests;
            failed_requests = 0;
            is_permanently_dead = false;
        }

        public int GetFailedRequests() { return failed_requests; }
        public int GetMaxFailedRequests() { return max_failed_requests; }
        public void SetMaxFailedRequests(int value) { max_failed_requests = value; }

        public override void Move(int x, int y)
        {
            failed_requests++;

            if (failed_requests >= max_failed_requests)
            {
                is_active = false;
                is_dead = true;
                is_permanently_dead = true;
            }
        }

        public override void Shift(int p)
        {
            if (p < 0 || p > row)
            {
                failed_requests++;
            }

            if (failed_requests >= max_failed_requests)
            {
                is_active = false;
                is_dead = true;
                is_permanently_dead = true;
                return;
            }

            if (p >= 0)
            {
                attack_range = p;
                return;
            }
            return;
        }

        public void Revive()
        {
            if (!is_permanently_dead)
            {
                is_active = true;
                failed_requests = 0;
            }
        }
    }
}
