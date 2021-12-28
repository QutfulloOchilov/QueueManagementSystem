package tj.behruz.queuemanagement.presentation.master

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.MasterItemBinding

class MasterAdapter(val itemHandler: (String) -> Unit) :
    RecyclerView.Adapter<MasterAdapter.MasterViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MasterViewHolder {
        val binding = MasterItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return MasterViewHolder(binding)
    }

    override fun onBindViewHolder(holder: MasterViewHolder, position: Int) {
        holder.itemView.setOnClickListener {
            itemHandler.invoke(holder.binding.masterName.text.toString())
        }
    }

    override fun getItemCount() = 4

    inner class MasterViewHolder(val binding: MasterItemBinding) :
        RecyclerView.ViewHolder(binding.root)


}