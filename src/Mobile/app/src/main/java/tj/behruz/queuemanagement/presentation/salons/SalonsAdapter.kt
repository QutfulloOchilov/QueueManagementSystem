package tj.behruz.queuemanagement.presentation.salons

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.SalonItemBinding
import tj.behruz.queuemanagement.domain.entity.Salon

class SalonsAdapter(val salons: List<Salon>, val onItemClick: (Salon) -> Unit) :
    RecyclerView.Adapter<SalonsAdapter.SalonsViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): SalonsViewHolder {
        val binding = SalonItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return SalonsViewHolder(binding)
    }

    override fun onBindViewHolder(holder: SalonsViewHolder, position: Int) {
        holder.setSalon(salons[position])
        holder.itemView.setOnClickListener {
            onItemClick.invoke(salons[position])
        }
    }

    override fun getItemCount() = salons.size

    inner class SalonsViewHolder(val binding: SalonItemBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun setSalon(salon: Salon) {
            with(binding) {
                salonIcon.setImageResource(salon.logo)
                salonName.text = salon.name
                rate.text = "Рейтинг ${salon.rate}"
            }
        }

    }


}