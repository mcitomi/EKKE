package com.tamas.berdo.todoapplication

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class MyAdapter (private val dataset: ArrayList<String>) : RecyclerView.Adapter<MyAdapter.ViewHolder>() {
    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.list_item, parent,false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(
        holder: ViewHolder,
        position: Int
    ) {
        holder.textView.text = dataset[position]
    }

    override fun getItemCount(): Int {
        return dataset.size
    }

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textView : TextView
        init {
            textView = view.findViewById(R.id.textView)
        }
    }
}